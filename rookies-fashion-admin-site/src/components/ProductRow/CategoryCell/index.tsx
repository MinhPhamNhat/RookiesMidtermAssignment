import { Product } from "../../../types/model";

const CategoryCell = ({product, handleCategoryClick}:any) => {
  return (
    <span>
      {!product.Category.IsParent ? (
        <a
          href="#"
          onClick={() =>
            handleCategoryClick(product.Category.Parent.CategoryId)
          }
        >
          {product.Category.Parent.Name},{" "}
        </a>
      ) : (
        <></>
      )}
      {
        <a
          href="#"
          onClick={() => handleCategoryClick(product.Category.CategoryId)}
        >
          {product.Category.Name}
        </a>
      }
    </span>
  );
};

export default CategoryCell;
