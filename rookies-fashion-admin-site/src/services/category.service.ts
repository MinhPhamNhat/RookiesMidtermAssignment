import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";
import CategoryPagingQuery from "../types/form/CategoryPagingQuery";

class CategoryService {
  async getCategories() {
    const endpoint = Endpoints.CATEGORIES;
    const response = await HttpClient.get(endpoint);
    return response;
  }
  async getPagingCategories(query: CategoryPagingQuery) {
    const endpoint = Endpoints.CATEGORIES + "/filter";
    const response = await HttpClient.get(endpoint, query);
    return response;
  }

  async getCategoryById(id: string) {
    const endpoint = Endpoints.CATEGORIES + `/${id}`;
    const response = await HttpClient.get(endpoint);
    return response;
  }
}

export default new CategoryService();
