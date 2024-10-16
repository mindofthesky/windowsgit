import React from "react";
import { TextProps } from "../../../types";
import Text from "../Text/Text";
import { DescWrap } from "./descStyle";
import { useTheme } from "styled-components";

const Desc: React.FC<TextProps> = (props) => {
  const theme = useTheme();
  const { content, fontWeight } = props;
  return (
    <>
      <DescWrap>
        <Text
          content={content}
          color={theme.colors.sub}
          fontWeight={fontWeight}
        />
      </DescWrap>
    </>
  );
};

export default Desc;
