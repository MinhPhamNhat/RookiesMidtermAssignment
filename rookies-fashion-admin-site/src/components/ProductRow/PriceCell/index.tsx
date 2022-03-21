import { Product } from "../../../types/model";

const PriceCell = ({ product }: any) => {
  return <span>${product.Price}</span>;
};
export default PriceCell;
