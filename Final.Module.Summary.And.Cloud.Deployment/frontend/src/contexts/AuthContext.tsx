import { createContext, useState } from "react";

interface AuthContextType {
  isLoggedIn: boolean;
  token: string;
  login: (token: string) => void;
  logout: () => void;
}

const initialValues:AuthContextType = {
  isLoggedIn: false,
  token: "",
  login: () => {},
  logout: () => {},
};

const AuthContext = createContext(initialValues);

function AuthProvider(props) {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [token, setToken] = useState("");

  function login(token: string) {
    setIsLoggedIn(true);
    setToken(token);
  }

  function logout() {
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
