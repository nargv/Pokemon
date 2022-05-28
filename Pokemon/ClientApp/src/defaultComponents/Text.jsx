import React from 'react';
import styled from 'styled-components';

const Text = (props) => {

    const getText = () => {
        if(props.type === "large") {
            return (
                <LargeText>{props.children}</LargeText>
            );
        } else if(props.type === "medium") {
            return (
                <MediumText>{props.children}</MediumText>
            );
        } else {
            return (
                <SmallText>{props.children}</SmallText>
            );
        }
    }

    return (
        <div>
            {getText()}
        </div>
    );
}

export default Text;

const LargeText = styled.p`
    font-size: 30px;
`;

const MediumText = styled.p`
    font-size: 18px;
`;

const SmallText = styled.p`
    font-size: 11px;
    color: red;
`;