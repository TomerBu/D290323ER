import axios, { AxiosRequestConfig } from "axios";

const baseUrl = import.meta.env.VITE_BASE_URL;

const client = axios.create({
  baseURL: baseUrl,
  headers: {
    Authorization: `Bearer ${localStorage.getItem("token")}`,
  },
});

const onSuccess = (response) => {
  console.debug("Request Successful!", response);
  return response;
};

const onError = (error) => {
  console.error("Request Failed:", error);
  return error;
};

const request = (options: AxiosRequestConfig) => {
   return client(options).then(onSuccess).catch(onError);
}

//request({ url: "/products", method: "GET" })
export default request;
