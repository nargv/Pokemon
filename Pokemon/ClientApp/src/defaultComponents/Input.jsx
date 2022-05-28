import React, { useState } from 'react';
import styled from 'styled-components';
import Text from './Text';

const Input = (props) => {

    const [showWarning, setShowWarning] = useState(false);

    const handleOnValueChange = (event) => {
        if(props.onValidation && props.onValidation(event.target.value) === false) {
            setShowWarning(true);
        } else {
            props.onValueChange(event.target.value);
            setShowWarning(false);
        }
    }

    return (
        <div>
            <Text type={"large"}>{props.label}</Text>
            <StyledInput type="text" onChange={handleOnValueChange} />
            {showWarning && (
                <Text type={"small"}>{props.warningMessage}</Text>
            )}
        </div>
    );
}

export default Input;

const StyledInput = styled.input`
    border: 2px solid red;
    border-radius: 4px;
`;