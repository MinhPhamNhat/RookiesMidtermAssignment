import HttpClient from "../utils/HttpClient";
import { Endpoints } from "../constants";

class UserService {
  async getUsers() {
    const endpoint = Endpoints.USERS;
    const response = await HttpClient.get(endpoint);
    return response;
  }
}
export default new UserService();
