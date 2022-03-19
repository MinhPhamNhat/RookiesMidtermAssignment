import React from "react";
import { Form } from "react-bootstrap";
const InputSection: React.FC<any> = (props) => {
  const { title, component } = props;
  return (
    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
      <Form.Label>
        <strong>{title}</strong>
      </Form.Label>
      {component}
    </Form.Group>
  );
};

export default InputSection;
