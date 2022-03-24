import { SortOrder } from "../../constants";

export type Sort = {
    ALL: SortOrder.ALL,
    NAME_ASC: SortOrder.NAME_ASC,
    NAME_DESC: SortOrder.NAME_DESC,
    PRICE_ASC: SortOrder.PRICE_ASC,
    PRICE_DESC: SortOrder.PRICE_DESC,
    RATING_ASC: SortOrder.RATING_ASC,
    RATING_DESC: SortOrder.RATING_DESC,
    CREATED_DATE_ASC: SortOrder.CREATED_DATE_ASC,
    CREATED_DATE_DESC: SortOrder.CREATED_DATE_DESC,
};

