import { aboutMembers } from "../../datas/aboutItems";
import {
  AboutInfoBox,
  AboutLeaderList,
  AboutLeaderRows,
  AboutNick,
  AboutPosition,
  AboutThumb,
  AboutThumbInfoWrap,
} from "../../styles/about/aboutMemberStyle";

const AboutRowOne = () => {
  if (aboutMembers.length === 0) {
    return null;
  }

  const leader = aboutMembers[0];

  return (
    <AboutLeaderRows>
      <AboutLeaderList>
        <AboutThumb>
          <img src={leader.members[0].img} alt={leader.members[0].nick} />
          <AboutThumbInfoWrap>
            <AboutInfoBox>
              <AboutNick>{leader.members[0].nick}</AboutNick>
              <AboutPosition>{leader.members[0].position}</AboutPosition>
            </AboutInfoBox>
          </AboutThumbInfoWrap>
        </AboutThumb>
      </AboutLeaderList>
    </AboutLeaderRows>
  );
};

export default AboutRowOne;
