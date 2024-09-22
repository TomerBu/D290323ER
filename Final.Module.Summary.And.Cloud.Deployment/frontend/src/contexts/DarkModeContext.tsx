// Data store (context) for dark mode

//state variable: isDark
//function to toggle dark mode

import { createContext, useState } from "react";

const initialValues = {
  darkMode: false,
  toggle: () => {},
};

const DarkModeContext = createContext(initialValues);

function DarkModeProvider({ children }) {

  //state variables:  
  const [darkMode, setDarkMode] = useState(false);

  //functions:
  function toggle() {
    setDarkMode((prev) => !prev);
  }

  return (
    <DarkModeContext.Provider value={{ darkMode, toggle }}>
      {children}
    </DarkModeContext.Provider>
  );
}

export { DarkModeProvider, DarkModeContext };

//useContext(DarkModeContext) to access the context in a component



