import { ratingStar } from "../../../helpers";
import { Product } from "../../../types/model";

const ThumbnailCell = ({ product }: any) => {
  return (
    <span>
      <img className="product-thumbnail" src={product.Thumbnail[0]?.ImageUrl} />
    </span>
  );
};
export default ThumbnailCell;
