import { Navigate } from "react-router-dom";
import { FCP } from "../@types";
import useAuth from "../hooks/useAuth";

const NoAuthRoute: FCP = ({ children }) => {
  const { isLoggedIn } = useAuth();

  if (isLoggedIn) {
    return <Navigate to="/" />;
  }
  return children;
};

export default NoAuthRoute;
