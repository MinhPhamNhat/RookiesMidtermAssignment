import { SortOrder } from "../../constants";

 type CategoryPagingQuery = {
    Search?: string;
    Page?: number;
    IsParent?: boolean;
    SortOrder?: SortOrder,
    Limit?: number;
}
export default CategoryPagingQuery;
