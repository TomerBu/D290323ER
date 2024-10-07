import { Link } from "react-router-dom";
import useProducts from "../hooks/useProducts";

const Products = () => {
  const { products, loading, error } = useProducts();

  return (
    <div>
      <h1 className="text-center mb-3 text-3xl">Products</h1>

      {error && <p>Error: {error.message ?? "something went wrong"}</p>}
      {loading && <p>Loading...</p>}
      {!loading && !error && (
        <ul>
          {products &&
            products.map((p) => (
              <li className="flex p-4 shadow-lg" key={p.id}>
                <Link to={`${p.id}`}>
                  <h2>{p.name}</h2>
                </Link>
              </li>
            ))}
        </ul>
      )}
    </div>
  );
};

export default Products;
