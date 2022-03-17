import { confirmAlert } from "react-confirm-alert";
import "./index.css";
export const ShowDialog = (
  title: string,
  message: string,
  onAccepted?: any,
  id?: any
) => {
  confirmAlert({
    customUI: ({ onClose }) => {
      return (
        <div className="custom-ui">
          <h1>{title}</h1>
          <p>{message}</p>
          <div className="dialog-button">
            <button
              onClick={() => {
                onClose();
              }}
            >
              No
            </button>
            <button
              onClick={() => {
                onAccepted(id);
                onClose();
              }}
            >
              Yes
            </button>
          </div>
        </div>
      );
    },
  });
};

export function ratingStar(val: number) {
  var element = []
  for (var i = 0; i < 5; i++) {
    if (val - i >= 1) {
      element.push(
        <span key={i}>
          <i className="fas fa-star"></i>
        </span>
      );
    } else if (val - i > 0 && val - i < 1) {
      element.push(
        <span key={i}>
          <i className="fas fa-star-half-alt"></i>
        </span>
      );
    } else {
      element.push(
        <span key={i}>
          <i className="fa-regular fa-star"></i>
        </span>
      );
    }
  }
  return  element;
}
