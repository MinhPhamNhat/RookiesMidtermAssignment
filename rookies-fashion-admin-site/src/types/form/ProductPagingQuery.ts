import { SortOrder } from "../../constants";

type ProductPagingQuery = {
    Search?: string;
    CategoryId?: number;
    Page?: number;
    Rating?: number;
    SortOrder?: SortOrder,
    Limit?: number;
}
export default ProductPagingQuery;

