import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";

class SizeService {
  async getSizes() {
    const endpoint = Endpoints.SIZES;
    const response = await HttpClient.get(endpoint);
    return response;
  }
}
export default new SizeService();
