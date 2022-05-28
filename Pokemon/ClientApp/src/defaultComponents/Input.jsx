import React, { useState } from 'react';
import styled from 'styled-components';
import Text from './Text';

const Input = (props) => {

    const handleOnValueChange = (event) => {
        if(props.onValidation) {
            props.onValidation(event.target.value)
        }
    }

    return (
        <div>
            {props.label && (
                <Text type={"large"}>{props.label}</Text>
            )}
            <StyledInput type="text" onChange={handleOnValueChange} />
            {!props.hideWarning && (
                <Text type={"small"}>{props.warningMessage}</Text>
            )}
        </div>
    );
}

export default Input;

const StyledInput = styled.input`
    border: 2px solid grey;
    border-radius: 4px;
    height: 40px;
    font-size: 20px;
`;