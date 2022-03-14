import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";

class CategoryService {
  async getCategories() {
    const endpoint = Endpoints.CATEGORIES;
    const response = await HttpClient.get(endpoint);
    return response;
  }

  async getCategoryById(id: string) {
    const endpoint = Endpoints.CATEGORIES + `/${id}`;
    const response = await HttpClient.get(endpoint);
    return response;
  }
}

export default new CategoryService();
