import { ReactNode } from "react";
import { FC } from "../@types";

type CardProps = {
    title: string;
    children: ReactNode;
}
 
const Card:FC<CardProps> = ({title, children}) => {
  return (
    <div className="bg-white p-6 shadow-lg rounded-lg">
        <h2 className="text-xl font-semibold mb-2">{title}</h2>
        <div>{children}</div>
    </div>
  );
};

export default Card;