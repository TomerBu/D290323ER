import { ReactNode } from "react";
export type FC<T> = (props: T) => ReactNode;
export type FCP = FC<{ children: ReactNode }>;

export type ProductType = {
  id: number;
  name: string;
  price: number;
  category: string;
  description: string;
  imageUrl: string;
};
