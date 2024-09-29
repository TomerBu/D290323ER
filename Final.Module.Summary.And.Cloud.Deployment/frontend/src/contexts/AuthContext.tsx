import { createContext, useState } from "react";

export interface AuthContextType {
  isLoggedIn: boolean;
  token: string;
  login: (token: string) => void;
  logout: () => void;
}
 
const AuthContext = createContext<AuthContextType>(null);

function AuthProvider(props) {
  const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("token"));
  const [token, setToken] = useState(localStorage.getItem("token") ?? "");

  function login(token: string) {
    localStorage.setItem("token", token);
    setIsLoggedIn(true);
    setToken(token);
  }

  function logout() {
    localStorage.removeItem("token");
    setIsLoggedIn(false);
    setToken("");
  }

  return (
    <AuthContext.Provider value={{ isLoggedIn, token, login, logout }}>
      {props.children}
    </AuthContext.Provider>
  );
}

export { AuthProvider, AuthContext };