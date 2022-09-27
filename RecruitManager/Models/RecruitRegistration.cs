using System.ComponentModel.DataAnnotations;

namespace RecruitManager.Models
{
    // 모집 신청 테이블
    public class RecruitRegistration
    {
        public int Id { get; set; }
        public int? RecruitSettingId { get; set; }

        [Display(Name = "게시판 이름")]
        [MaxLength(50)]
        [Required(ErrorMessage = "게시판 이름을 입력하세요.")]
        public string? BoardName { get; set; }

        [Display(Name = "게시판 번호")]
        [Required(ErrorMessage = "게시판 번호를 입력하세요.")]
        [Range(0, int.MaxValue, ErrorMessage = "숫자값을 입력하세요.")]
        public int? BoardNum { get; set; }

        [MaxLength(150)]
        [Display(Name = "게시물 제목")]
        public string? BoardTitle { get; set; }

        [Display(Name = "등록일")]
        public DateTimeOffset CreationDate { get; set; }    //Default GetDate()

        public int? UserId { get; set; }
        
        [MaxLength(25)]
        [Required(ErrorMessage = "로그인 사용자 아이디를 입력하세요.")]
        public string Username { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NickName { get; set; }
    }
}
