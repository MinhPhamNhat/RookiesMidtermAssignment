import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";
import { ProductForm } from "../types/form/ProductForm";
import ProductPagingQuery from "../types/form/ProductPagingQuery";

class ProductService {
  async getProducts(query: ProductPagingQuery) {
    const endpoint = Endpoints.PRODUCTS;
    const response = await HttpClient.get(endpoint, query);
    return response;
  }
  async getProductById(id: string) {
    const endpoint = Endpoints.PRODUCTS + `/${id}`;
    const response = await HttpClient.get(endpoint);
    return response;
  }
  async insertProduct(form: FormData) {
    const endpoint = Endpoints.PRODUCTS;
    const response = await HttpClient.post(endpoint, form);
    return response;
  }
  async updateProduct(id: string, form: FormData) {
    const endpoint = Endpoints.PRODUCTS + `/${id}`;
    const response = await HttpClient.put(endpoint, form);
    return response;
  }
  async deleteProduct(id: string) {
    const endpoint = Endpoints.PRODUCTS + `/${id}`;
    const response = await HttpClient.delete(endpoint);
    return response;
  }
}
export default new ProductService();
