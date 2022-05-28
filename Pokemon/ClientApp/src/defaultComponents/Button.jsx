import React from 'react';
import styled from 'styled-components';

const Button = (props) => {
    return (
        <StyledButton onClick={props.handleOnClick}>
            {props.children}
        </StyledButton>
    );
}

export default Button;

const StyledButton = styled.button`
    border: 2px solid grey;
    border-radius: 4px;
    height: 40px;
    &:hover {
        background-color: darkgrey;
    }
`;