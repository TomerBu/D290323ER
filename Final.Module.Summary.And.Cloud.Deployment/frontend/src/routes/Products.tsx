import useAuth from "../hooks/useAuth";
import { getProducts } from "../services/products-service";

const Products = () => {
  const { token } = useAuth();
  getProducts(token)
    .then((response) => {
      console.log(response.data);
    })
    .catch((error) => {
      console.error(error);
    });
  return <div>Products</div>;
};

export default Products;
