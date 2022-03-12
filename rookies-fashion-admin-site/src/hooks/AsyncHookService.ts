import React, { useState, useEffect } from "react";
import { Response } from "../types/model";

export const useAsyncService = (service: any) => {
  // const [resp, setResp] = useState({})
  // useEffect(()=>{
  //     const getService = async () => {
  //         const myResp = service
  //         setResp(myResp)
  //     }
  //     getService();
  // },[])
  // return resp;
};
export const useReducer = (callback: any, callbackParams?: any) => {
  useEffect(() => {
    callback(callbackParams);
  }, [callback]);
};
