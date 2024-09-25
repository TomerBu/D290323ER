import axios from "axios";

const baseUrl = "https://localhost:7037/api/auth";

const register = (email: string, username: string, password: string) =>
  axios.post(`${baseUrl}/register`, { email, username, password });

//after successful login, the server will return a token
//and we will store it in the local storage
const login = (email: string, password: string) =>
  axios.post(`${baseUrl}/login`, { email, password }).then((response) => {
    if (response.data.token) {
      localStorage.setItem("token", JSON.stringify(response.data));
    }
    return response;
  });

export { register, login };

export const auth = { register, login };
