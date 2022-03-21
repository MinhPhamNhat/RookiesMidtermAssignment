import { confirmAlert } from "react-confirm-alert";
import { NOTIFICATION_TYPE, Store } from "react-notifications-component";
import ConfirmDialog from "../components/ConfirmDialog";
export const ShowDialog = (
  title: string,
  component: JSX.Element,
  onAccepted?: any,
) => {
  confirmAlert({
    customUI: ({ onClose }) => {
      return ( <ConfirmDialog title={title} component={component} onConfirm={onAccepted} onCancel={onClose}/>
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


export const ShowNotification = (
  message: string,
  title: string,
  type: NOTIFICATION_TYPE
) => {
  Store.addNotification({
    title: title,
    message: message,
    type: type,
    insert: "top",
    container: "bottom-right",
    animationIn: ["animate__animated", "animate__fadeIn"],
    animationOut: ["animate__animated", "animate__fadeOut"],
    dismiss: {
      duration: 5000,
      onScreen: true,
    },
  });
};

