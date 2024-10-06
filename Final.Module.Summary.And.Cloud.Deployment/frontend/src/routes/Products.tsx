import useProducts from "../hooks/useProducts";

const Products = () => {
  const { products, loading, error } = useProducts();

  return (
    <div>
      <h1>Products</h1>
      {error && <p>Error: {error.message ?? "something went wrong"}</p>}
      {loading && <p>Loading...</p>}
      {!loading && !error && (
        <ul>
          {products.map((p) => (
            <li key={p.id}>{p.name}</li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Products;
