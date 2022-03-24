import { Response } from "../../types/model";
import { ValidationError } from "../../types/model/ValidationError";
import axios from "./base";

function getToken() {
  try {
    return localStorage.getItem("token");
  } catch (error) {
    return null;
  }
}

class HttpClient {
  token: string | null = "";

  constructor() {
    // axios.defaults.headers.common["content-type"] = "application/json"
    // axios.defaults.headers.common["access-control-allow-origin"] = "*"
  }

  async get(endpoint: string, data?: object): Promise<Response> {
    this.token = getToken();
    const response = await axios
      .get(`${endpoint}`, {
        params: data,
      })
      .then((res: any) => {
        return {
          code: res.status,
          message: res.data.Message,
          data: res.data.Data,
        };
      })
      .catch((err: any) => {
        return {
          code: err.response.status,
          message: err.response.message,
          data: undefined,
        };
      });
    return response;
  }

  async post(endpoint: string, formData?: any): Promise<Response> {
    this.token = getToken();
    const response = await axios
      .post(`${endpoint}`, formData)
      .then((res: any) => {
        return {
          code: res.status,
          message: res.data.Message,
          data: res.data.Data,
        };
      })
      .catch((err: any) => {
        console.log(err.response)
        return {
          code: err.response.status,
          message: err.response.data.Message,
          data: err.response.data.Data as Array<ValidationError>,
        };
      });
    return response;
  }

  async put(endpoint: string, formData?: any): Promise<Response> {
    this.token = getToken();
    const response = await axios
      .put(`${endpoint}`, formData)
      .then((res: any) => {
        return {
          code: res.status,
          message: res.data.Message,
          data: res.data.Data,
        };
      })
      .catch((err: any) => {
        return {
          code: err.response.status,
          message: err.response.data.Message,
          data: err.response.data.Data as Array<ValidationError>,
        };
      });
    return response;
  }

  async delete(endpoint: string, data?: object): Promise<Response> {
    this.token = getToken();
    const response = await axios
      .delete(`${endpoint}`, {
        data: data,
      })
      .then((res: any) => {
        return {
          code: res.status,
          message: res.data.Message,
          data: res.data.Data,
        };
      })
      .catch((err: any) => {
        return {
          code: err.response.status,
          message: err.response.data.message,
          data: undefined,
        };
      });
    return response;
  }
}

const responeParse = (resp: any) => {
  switch(resp.status){
    case 400:
      return {
        code: resp.status,
        message: resp.data.Message,
        data: resp.data.Data as Array<ValidationError>,
      };

  }
}

export default new HttpClient();
