import React from "react";

import ThumbnailCell from "./ThumbnailCell";
import NameCell from "./NameCell";
import CreatedDateCell from "./CreatedDateCell";
import PriceCell from "./PriceCell";
import RatingCell from "./RatingCell";
import CategoryCell from "./CategoryCell";
import ActionCell from "./ActionCell";

const ProductRow: React.FC<any> & {
    Thumbnail: typeof ThumbnailCell;
    Name: typeof NameCell;
    CreatedDate: typeof CreatedDateCell;
    Price: typeof PriceCell;
    Rating: typeof RatingCell;
    Category: typeof CategoryCell;
    Action: typeof ActionCell;
} = ({ children }): JSX.Element => <>{children}</>;

ProductRow.Thumbnail = ThumbnailCell;
ProductRow.CreatedDate = CreatedDateCell;
ProductRow.Name = NameCell;
ProductRow.Price = PriceCell;
ProductRow.Rating = RatingCell;
ProductRow.Category = CategoryCell;
ProductRow.Action = ActionCell;

export default ProductRow;
