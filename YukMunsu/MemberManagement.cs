using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 도서관리
{
    class MemberManagement // 회원 관리 class
    {
        Display display;
        Exception exception;
        private MemberVO memberData;
        public ArrayList memberNameList; // 회원 정보를 저장하는 ArrayList
        public ArrayList memberAgeList;
        public ArrayList memberAddressList;
        public ArrayList memberPhoneList;
        public ArrayList residentNumberList;
        public string num = "";
        public string address = "";
        public string phone = "";
        int exceptionNumber = 0; // 예외 변수
        int count = 0; // 등록 변수

        public MemberManagement(Display display) // 생성자
        {
            this.display = display;
            exception = new Exception(display);
            memberData = new MemberVO(); // 회원 정보 객체 생성
            memberNameList = new ArrayList();
            memberAgeList = new ArrayList();
            memberAddressList = new ArrayList();
            memberPhoneList = new ArrayList();
            residentNumberList = new ArrayList();

            memberNameList.Add("육문수");
            memberAgeList.Add("25");
            memberAddressList.Add("경기도 군포시 산본동"); // 테스트용
            memberPhoneList.Add("010-2929-3308");
            residentNumberList.Add("920603-1234567");
            memberNameList.Add("신재혁");
            memberAgeList.Add("23");
            memberAddressList.Add("경기도 안양시 만안구");
            memberPhoneList.Add("010-3213-2321");
            residentNumberList.Add("950124-1234567");
            memberNameList.Add("손흥민");
            memberAgeList.Add("25");
            memberAddressList.Add("잉글랜드 북런던 토트넘");
            memberPhoneList.Add("010-5678-7979");
            residentNumberList.Add("920725-1234567");
        }

        public void enrollmentMember() // 회원 등록 메소드
        {
            Console.Clear();
            while (count < 5)
            {
                if (count == 0)
                {
                    display.inputDisplay("회원명", 1);
                    memberData.MemberName = Console.ReadLine();
                    exceptionNumber = exception.nameException(memberData.MemberName); // 예외처리후 정수값 리턴

                    if (exceptionNumber == 0) // 예외처리 통과하면
                    {
                        memberNameList.Add(memberData.MemberName); // 이름 추가
                        count++;
                    }
                }

                else if (count == 1)
                {
                    display.inputDisplay("나이", 1);
                    memberData.MemberAge = Console.ReadLine();
                    exceptionNumber = exception.ageException(memberData.MemberAge);

                    if (exceptionNumber == 0)
                    {
                        memberAgeList.Add(memberData.MemberAge);
                        count++;
                    }
                }

                else if (count == 2)
                {
                    display.inputDisplay("xx도 xx시 xx동 으로 입력", 2);
                    display.inputDisplay("주소", 1);
                    memberData.MemberAddress = Console.ReadLine();
                    exceptionNumber = exception.addressException(memberData.MemberAddress);

                    if (exceptionNumber == 0)
                    {
                        memberAddressList.Add(memberData.MemberAddress);
                        count++;
                    }
                }

                else if (count == 3)
                {
                    display.inputDisplay("xxx-xxxx-xxxx 로 입력해주세요", 2);
                    display.inputDisplay("핸드폰번호", 1);
                    memberData.MemberPhone = Console.ReadLine();
                    exceptionNumber = exception.phoneException(memberData.MemberPhone, "핸드폰 번호를 정확히 입력하세요");

                    if (exceptionNumber == 0)
                    {
                        memberPhoneList.Add(memberData.MemberPhone);
                        count++;
                    }
                }

                else if (count == 4)
                {
                    display.inputDisplay("xxxxxx-xxxxxxx 로 입력해주세요", 2);
                    display.inputDisplay("주민등록번호", 1);
                    memberData.ResidentNumber = display.hideResidentNumber();
                    exceptionNumber = exception.phoneException(memberData.ResidentNumber, "주민등록번호를 정확히 입력하세요");

                    if (exceptionNumber == 0)
                    {
                        residentNumberList.Add(memberData.ResidentNumber);
                        count++;
                    }
                }
            }
            display.printDisplay("등록 되었습니다");
            count = 0; // 다음 회원 등록하기 위해 초기화
        }

        public void updateMember() // 회원 수정 메소드
        {
            Console.Clear();
            while (num != "1" && num != "2" && num != "3" && num != "4")
            {
                display.printDisplay("수정할 항목");
                display.inputDisplay("1. 회원명 2. 나이 3. 주소 4. 핸드폰번호", 2);
                display.inputDisplay("입력", 1);
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        display.inputDisplay("기존 회원명", 1);
                        memberData.MemberName = Console.ReadLine();
                        memberUpdate(memberNameList, memberData.MemberName, "변경할 회원명"); // 회원명 수정
                        break;
                    case "2":
                        display.inputDisplay("회원명", 1);
                        memberData.MemberName = Console.ReadLine();
                        memberUpdate(memberAgeList, memberData.MemberAge, "변경할 나이"); // 나이 수정
                        break;
                    case "3":
                        display.inputDisplay("회원명", 1);
                        memberData.MemberName = Console.ReadLine();
                        memberUpdate(memberAddressList, memberData.MemberAddress, "변경할 주소"); // 주소 수정
                        break;
                    case "4":
                        display.inputDisplay("회원명", 1);
                        memberData.MemberName = Console.ReadLine();
                        memberUpdate(memberPhoneList, memberData.MemberPhone, "변경할 핸드폰번호"); // 핸드폰번호 수정
                        break;
                    default:
                        display.printDisplay("제대로 입력하세요");
                        break;
                }
            }
            num = "";
        }

        public void memberUpdate(ArrayList memberInfoList, string memberInfo, string str) // 회원 수정 방법 메소드
        {
            Console.Clear();
            for (int i = 0; i < memberNameList.Count; i++)
            {
                if (Convert.ToString(memberNameList[i]) == memberData.MemberName) // 이름이 있으면
                {
                    display.inputDisplay(str, 1);
                    memberInfo = Console.ReadLine(); // 수정할 내용 입력
                    memberInfoList[i] = memberInfo;
                    display.printDisplay("수정 되었습니다");
                }
                
            }
        }

        public void deleteMember() // 회원 삭제 메소드
        {
            Console.Clear();
            display.inputDisplay("삭제할 회원명", 1);
            memberData.MemberName = Console.ReadLine();

            for (int i = 0; i < memberNameList.Count; i++)
            {
                if (Convert.ToString(memberNameList[i]) == memberData.MemberName) // 회원명이 있으면
                {
                    memberNameList.RemoveAt(i);
                    memberAgeList.RemoveAt(i);
                    memberAddressList.RemoveAt(i); // ArrayList 값 전부 삭제
                    memberPhoneList.RemoveAt(i);
                    display.printDisplay("삭제 되었습니다");
                }
                else if (i == 0)
                {
                    display.inputDisplay("없는 회원입니다", 2);
                }
            }
        }

        public void memberSearch(ArrayList memberList, string memberInfo) // 회원 검색 방법 메소드
        {
            for (int i = 0; i < memberNameList.Count; i++)
            {
                if (Convert.ToString(memberList[i]) == memberInfo) // ArrayList 에 입력받은 값이 있으면
                {
                    display.memberInformation();
                    display.memberPrint(memberNameList[i], memberAgeList[i], memberAddressList[i], memberPhoneList[i], residentNumberList[i]); // 출력 메소드 호출
                    count++; // 검색되면 카운트 증가
                }
                else if (Convert.ToString(memberList[i]) != memberInfo && count < 1) // 검색이 한명도 안되었을 경우
                {
                    display.inputDisplay("없는 회원 입니다", 2);
                    break;
                }
            }
        }

        public void searchMember() // 회원 검색 메소드
        {
            Console.Clear();
            while (num != "1" && num != "2" && num != "3" && num != "4")
            {
                display.inputDisplay("검색할 방법", 2);
                display.inputDisplay("1. 회원명 2. 나이 3. 주소 4. 핸드폰번호", 2);
                display.inputDisplay("입력", 1);
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        display.inputDisplay("회원명", 1);
                        memberData.MemberName = Console.ReadLine();
                        memberSearch(memberNameList, memberData.MemberName); // 이름으로 검색
                        break;
                    case "2":
                        display.inputDisplay("나이", 1);
                        memberData.MemberAge = Console.ReadLine();
                        memberSearch(memberAgeList, memberData.MemberAge); // 나이로 검색
                        break;
                    case "3":
                        display.inputDisplay("도,시,구,동 아무거나 입력", 1);
                        memberData.MemberAddress = Console.ReadLine();

                        for (int i = 0; i < memberAddressList.Count; i++)
                        {
                            address = Convert.ToString(memberAddressList[i]); // ArrayList 값을 문자열로 변환
                            string[] strAddress = address.Split(' '); // 공백단위로 자르기
                            for (int j = 0; j < strAddress.Length; j++)
                            {
                                if (strAddress[j] == memberData.MemberAddress) // 그에 맞는 문자열이 있으면
                                {
                                    display.memberInformation();
                                    display.memberPrint(memberNameList[i], memberAgeList[i], memberAddressList[i], memberPhoneList[i], residentNumberList[i]); // 출력
                                    count++;
                                    break;
                                }
                                else if (strAddress[j] != memberData.MemberAddress && count < 0)
                                {
                                    display.inputDisplay("없는 주소입니다", 2);
                                }
                            }
                        }
                        count = 0;
                        break;
                    case "4":
                        display.inputDisplay("핸드폰 번호 뒷4자리 입력", 1);
                        memberData.MemberPhone = Console.ReadLine();

                        for (int i = 0; i < memberPhoneList.Count; i++)
                        {
                            phone = Convert.ToString(memberPhoneList[i]); // 문자열로 변환
                            if (phone.Substring(9) == memberData.MemberPhone) // 9째 자리부터 끝까지 4자리를 검사
                            {
                                display.memberInformation();
                                display.memberPrint(memberNameList[i], memberAgeList[i], memberAddressList[i], memberPhoneList[i], residentNumberList[i]);
                                break;
                            }
                            else if (phone.Substring(9) != memberData.MemberPhone && i == 0)
                            {
                                display.inputDisplay("없는 번호입니다", 2);
                            }
                        }
                        break;
                    default:
                        display.printDisplay("제대로 입력");
                        break;
                }
            }
            num = "";
        }

        public void printMember() // 회원 전체 출력 메소드
        {
            for (int i = 0; i < memberNameList.Count; i++) // ArrayList 전체 순회
            {
                Console.Write("                {0}      {1}      {2}      {3}       {4}", memberNameList[i], memberAgeList[i], memberAddressList[i], memberPhoneList[i], residentNumberList[i]);
                Console.WriteLine();
            }
        }
    }
}