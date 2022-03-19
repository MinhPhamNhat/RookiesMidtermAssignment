import { ratingStar } from "../../../helpers";
import { Product } from "../../../types/model";

const RatingCell = ({ product }: any) => {
  return (
    <span>
      <div className="product-rating">
        <div className="rating-stars">{ratingStar(product.AvgRating)}</div>
        <div className="rating-value">{product.AvgRating}/5</div>
      </div>
    </span>
  );
};
export default RatingCell;
