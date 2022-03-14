import React from "react";
const InputSection: React.FC<any> = (props) => {
    const {title, component} = props
  return (
    <>
      <div className="mb-3 row">
        <label className="col-sm-2">{title}</label>
        <div className="col-sm-10">
          {component}
        </div>
      </div>
      <div className="line"></div>
      <br />
    </>
  );
};

export default InputSection;
