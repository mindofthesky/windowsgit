import React from "react";
import { TextProps } from "../../../types";
import Text from "../Text/Text";

const Title: React.FC<TextProps> = (props) => {
  const { content } = props;

  return (
    <>
      <div className="title">
        <Text
          content={content}
          fontFamily="Montserrat"
          fontWeight="700"
          fontSize="60px"
          lineHeight="80px"
        />
      </div>
    </>
  );
};

export default Title;
