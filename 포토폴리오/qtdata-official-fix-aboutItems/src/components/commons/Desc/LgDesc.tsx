import React from "react";
import { TextProps } from "../../../types";
import Text from "../Text/Text";
import { LgDescWrap } from "./descStyle";

const LgDesc: React.FC<TextProps> = (props) => {
  const { content, color } = props;
  return (
    <>
      <LgDescWrap>
        <Text content={content} color={color} />
      </LgDescWrap>
    </>
  );
};

export default LgDesc;
