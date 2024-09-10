import { PiNotePencilBold } from "react-icons/pi";
import './ButtonRequest.css'


function ButtonRequest({ requestToAdding }) {

    return (
    <>
        <button className="RequestButton" onClick={requestToAdding}><PiNotePencilBold /> Create a card</button>
    </>
  );
}

export default ButtonRequest;