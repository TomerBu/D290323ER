import { useContext } from "react";
import { AuthContext } from "../contexts/AuthContext";

//hook is a function that starts with the word "use"
//the function may take arguments 
//the function may return a value
//the function may use other hooks!!!
//the difference between a hook and a regular function is that a hook can use other hooks
const useAuth = () => {
    const auth = useContext(AuthContext);

    if (!auth) {   //null or undefined
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return auth;
};


export default useAuth;
