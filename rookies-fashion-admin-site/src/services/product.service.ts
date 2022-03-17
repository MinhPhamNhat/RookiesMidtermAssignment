import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";
import { ProductForm } from "../types/form/ProductForm";
import { PagingForm } from "../types/form/PagingForm";

class ProductService {
  async getProducts(query: PagingForm) {
    const endpoint = Endpoints.PRODUCTS;
    const response = await HttpClient.get(endpoint, query);
    return response;
  }
  async getProductById(id: string) {
    const endpoint = Endpoints.PRODUCTS + `/${id}`;
    const response = await HttpClient.get(endpoint);
    return response;
  }
  async insertProduct(form: any) {
    const endpoint = Endpoints.PRODUCTS;
    const response = await HttpClient.post(endpoint, form);
    return response;
  }
}
export default new ProductService();
