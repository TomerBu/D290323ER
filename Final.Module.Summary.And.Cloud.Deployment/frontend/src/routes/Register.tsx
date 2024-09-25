import { ErrorMessage, Field, Form, Formik } from "formik";
import { useState } from "react";
import * as Yup from "yup";
import Spinner from "../components/Spinner";
import { dialog, showErrorDialog, showSuccessDialog } from "../dialogs/dialogs";
import { auth } from "../services/auth-service";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string>();

  const navigate = useNavigate();

  const validationSchema = Yup.object({
    email: Yup.string().email("Bad Email!").required("The email is required"),
    username: Yup.string().required().min(2).max(20),
    password: Yup.string()
      .required()
      .min(8)
      .max(20)
      .matches(
        /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*_-]).{8,30}$/,
        "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character"
      ),
    confirmPassword: Yup.string()
      .required()
      .oneOf([Yup.ref("password")], "Passwords must match"),
  });

  const initialValues = {
    email: "",
    username: "",
    password: "",
    confirmPassword: "",
  };
  return (
    <Formik
      initialValues={initialValues}
      validationSchema={validationSchema}
      onSubmit={(o) => {
        setIsLoading(true);
        auth
          .register(o.email, o.username, o.password)
          .then((response) => {
            showSuccessDialog("Registration Successful").then(() => {
              navigate("/login");
            });
          })
          .catch((error) => {
            showErrorDialog("Registration Failed");
          })
          .finally(() => {
            setIsLoading(false);
          });
      }}
    >
      <Form className="flex flex-col items-center">
        {isLoading && <Spinner title="WaitUp!" />}
        {error && <p className="text-red-500">{error}</p>}
        <div className="font-extralight form-group flex flex-col gap-2 w-1/2 mx-auto text-lg my-4">
          <label htmlFor="username">User Name</label>
          <Field
            name="username"
            type="text"
            id="username"
            className="rounded-md hover:border-2 border-2 px-2 py-2"
          />
          <ErrorMessage
            name="username"
            component="div"
            className="text-red-500"
          />
        </div>

        <div className="font-extralight form-group flex flex-col gap-2 w-1/2 mx-auto text-lg my-4">
          <label htmlFor="email">Email Address</label>
          <Field
            name="email"
            type="email"
            id="email"
            className="rounded-md hover:border-2 border-2 px-2 py-2"
          />
          <ErrorMessage name="email" component="div" className="text-red-500" />
        </div>

        <div className="font-extralight form-group flex flex-col gap-2 w-1/2 mx-auto text-lg my-4">
          <label htmlFor="password">Password</label>
          <Field
            name="password"
            type="password"
            id="password"
            className="rounded-md hover:border-2 border-2 px-2 py-2"
          />
          <ErrorMessage
            name="password"
            component="div"
            className="text-red-500"
          />
        </div>

        <div className="font-extralight form-group flex flex-col gap-2 w-1/2 mx-auto text-lg my-4">
          <label htmlFor="confirmPassword">Confirm Password</label>
          <Field
            name="confirmPassword"
            type="password"
            id="confirmPassword"
            className="rounded-md hover:border-2 border-2 px-2 py-2"
          />
          <ErrorMessage
            name="confirmPassword"
            component="div"
            className="text-red-500"
          />
        </div>

        <button
          disabled={isLoading}
          type="submit"
          className="bg-blue-500 disabled:bg-blue-500/50 w-1/2   block text-left hover:bg-blue-700 text-white font-bold py-2 px-4 rounded my-4"
        >
          Register
        </button>
      </Form>
    </Formik>
  );
};

export default Register;
