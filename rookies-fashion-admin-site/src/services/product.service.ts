import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";
import { ProductForm } from "../types/form/ProductForm";

class ProductService {
  async getProducts() {
    const endpoint = Endpoints.PRODUCTS;
    const response = await HttpClient.get(endpoint,{Limit: 10} );
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
