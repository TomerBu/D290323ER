// a react component is a function that takes props and returns a ReactNode

import { ReactNode } from "react";

//FC = FunctionComponent
export type FC<T> = (props: T) => ReactNode;

export type FCP = FC<{ children: ReactNode }>;
