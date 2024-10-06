import axios from "axios";

const url = import.meta.env.VITE_BASE_URL + "/products";

//DRY: Don't Repeat Yourself - 
export const getProducts = () => {
  return axios.get(url, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`,
    },
  });
};

export const getProduct = (id: number = 1) => {
  return axios.get(url + "/" + id, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`,
    },
  });
};
