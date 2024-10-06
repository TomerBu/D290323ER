import { useState, useEffect } from "react";
import { ProductType } from "../@types";
import { getProducts } from "../services/products-service";

const useProducts  = () => {
  const [products, setProducts] = useState<ProductType[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    setLoading(true);
    getProducts()
      .then((response) => {
        setProducts(response.data);
      })
      .catch((error) => {
        setError(error);
      })
      .finally(() => {
        setLoading(false);
      });
  }, []);

  return { products, loading, error };
};

export default useProducts;
