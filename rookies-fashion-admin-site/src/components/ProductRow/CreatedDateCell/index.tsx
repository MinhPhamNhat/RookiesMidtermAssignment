import { Product } from "../../../types/model";

const CreatedDateCell = ({ product }: any) => {
  return (
    <span>
      {new Date(product.CreatedDate).toLocaleTimeString("en-US", {
        year: "numeric",
        month: "long",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
      })}
    </span>
  );
};

export default CreatedDateCell;
