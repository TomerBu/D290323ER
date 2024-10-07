import request from "../utils/axios-interceptors";

const productUrl = "/products";

export const getProducts = () =>
  request({
    url: productUrl,
  });

export const getProduct = (id: number) =>
  request({
    url: `${productUrl}/${id}`,
  });
