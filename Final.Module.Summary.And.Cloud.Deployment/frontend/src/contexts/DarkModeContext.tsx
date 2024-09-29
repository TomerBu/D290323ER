// Data store (context) for dark mode

//state variable: isDark
//function to toggle dark mode

import { createContext, useEffect, useState } from "react";

export interface DarkModeContextType {
  darkMode: boolean;
  toggle: () => void;
}
const DarkModeContext = createContext<DarkModeContextType>(null);

function DarkModeProvider({ children }) {

  useEffect(() => {
    const mode = localStorage.getItem("darkMode");
    if (mode === "dark") {
      setDarkMode(true);
      document.body.classList.toggle("dark");
    }
  }, []);
 
  const [darkMode, setDarkMode] = useState(false);

  //functions:
  function toggle() {
    //calculate the new state as a string: "dark" or "light":
    const newMode = !darkMode ? "dark" : "light";

    //save the new state to local storage:
    localStorage.setItem("darkMode", newMode);

    setDarkMode((prev) => !prev);

    document.body.classList.toggle("dark");
  }

  return (
    <DarkModeContext.Provider value={{ darkMode, toggle }}>
      {children}
    </DarkModeContext.Provider>
  );
}

export { DarkModeProvider, DarkModeContext };

//useContext(DarkModeContext) to access the context in a component
