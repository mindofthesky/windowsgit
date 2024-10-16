import React from "react";
import { neosDescs } from "../../datas/neosItems";
import {
  LevTwoDesc,
  LevTwoContent,
  LevTwoContentBox,
  LevTwoName,
  NeosLevTwoWrap,
  MNeosTwoSwrap,
  MBlueCircle,
  MTwoName,
  MTwoDesc,
  MCrossImgTop,
  MCrossImgDown,
  CrossImg,
} from "../../styles/joosikbox/neos";

const NeosLevTwo = () => {
  return (
    <>
      <NeosLevTwoWrap>
        <LevTwoContentBox>
          {neosDescs.map((item, index) => (
            <LevTwoContent key={index}>
              {item.showCross && (
                <CrossImg src="/assets/cross_blue.svg" alt="cross_blue" />
              )}
              <LevTwoName>{item.name}</LevTwoName>
              <LevTwoDesc>{item.desc}</LevTwoDesc>
            </LevTwoContent>
          ))}
        </LevTwoContentBox>
      </NeosLevTwoWrap>
      {/* 모바일 */}
      <MNeosTwoSwrap>
        <MCrossImgTop src="/assets/cross_white.svg" alt="cross_white" />
        {neosDescs.map((item, index) => (
          <MBlueCircle key={index}>
            <MTwoName>{item.name}</MTwoName>
            <MTwoDesc>{item.desc}</MTwoDesc>
          </MBlueCircle>
        ))}

        <MCrossImgDown src="/assets/cross_white.svg" alt="cross_white" />
      </MNeosTwoSwrap>
    </>
  );
};

export default NeosLevTwo;
