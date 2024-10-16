import {
  ContinueDesc,
  ContinueDescBox,
  JoosikContainer,
  JoosikLayout,
  TobeContinue,
} from "../../styles/joosikbox/joosikboxStyle";

const Neos = () => {
  return (
    // <NeosWrap>
    //   <div>
    //     <NeosLevOne />
    //     <NeosLevTwo />
    //     <NeosLevThr />
    //     <NeosLevFour />
    //     <NeosLevFif />
    //     <NeosLevSix />
    //   </div>
    // </NeosWrap>

    <JoosikLayout>
      <JoosikContainer>
        <ContinueDescBox>
          <TobeContinue>주식박스에서 곧 만나요.</TobeContinue>
          <ContinueDesc>
            대한민국을 넘어 세계최고가 되고자 하는 퀀텀데이터의 주식박스가 곧
            찾아옵니다. <br /> 다양한 정보와 정확한 데이터로 세상에 없던
            서비스를 보여드릴 이곳에서 당신만의 투자를 한껏 펼칠 수 있게 되길
            바랍니다.
          </ContinueDesc>
        </ContinueDescBox>
      </JoosikContainer>
    </JoosikLayout>
  );
};

export default Neos;
