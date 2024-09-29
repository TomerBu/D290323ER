import axios from "axios";

const url = import.meta.env.VITE_BASE_URL + "/products";

export const getProducts = (jwt: string) => {
  return axios.get(url, {
    headers: {
      Authorization: `Bearer ${jwt}`,
    },
  });
};
