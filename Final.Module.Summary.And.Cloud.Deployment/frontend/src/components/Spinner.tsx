import { CirclesWithBar } from "react-loader-spinner";

const Spinner = (props) => {
  return (
    <>
      <p className="text-center">{props.title ?? "Loading please wait"}</p>
      <CirclesWithBar
        wrapperClass="flex justify-center items-center"
        height={100}
        color="#ffdd00"
        outerCircleColor="#ff00ff"
        innerCircleColor="#dd00dd"
        barColor="#dd88dd"
      />
    </>
  );
};

export default Spinner;
