import React from "react";
import "./index.css";
const ConfirmDialog: React.FC<any> = ({
  title,
  component,
  onConfirm,
  onCancel,
}: any) => {
  return (
    <div className="custom-ui">
      <span className="dialog-title"><i className="fa-solid fa-trash-can"></i><h1>{title}</h1></span>
      {component}
      <div className="dialog-button">
        <button className="" onClick={onCancel}>No</button>
        <button onClick={onConfirm}>Confirm</button>
      </div>
    </div>
  );
};

export default ConfirmDialog;
