import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";

class ColorService {
  async getColors() {
    const endpoint = Endpoints.COLORS;
    const response = await HttpClient.get(endpoint);
    return response;
  }
}
export default new ColorService();
