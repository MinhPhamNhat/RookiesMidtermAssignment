import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";
import CategoryPagingQuery from "../types/form/CategoryPagingQuery";
import { CategoryForm } from "../types/form/CategoryForm";

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

  async getParentCategories() {
    const endpoint = Endpoints.CATEGORIES + "/parents";
    const response = await HttpClient.get(endpoint);
    return response;
  }

  async insertCategory(form: CategoryForm) {
    const endpoint = Endpoints.CATEGORIES;
    const response = await HttpClient.post(endpoint, form);
    return response;
  }

  async updateCategory(id: string, form: CategoryForm) {
    const endpoint = Endpoints.CATEGORIES+ `/${id}`;
    const response = await HttpClient.put(endpoint, form);
    return response;
  }

  async deleteCategory(id: string) {
    const endpoint = Endpoints.CATEGORIES+ `/${id}`;
    const response = await HttpClient.delete(endpoint);
    return response;
  }
}

export default new CategoryService();
